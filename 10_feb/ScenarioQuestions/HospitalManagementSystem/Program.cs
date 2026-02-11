using System;
using System.Collections.Generic;
using System.Linq;

public interface IPatient
{
    int PatientId { get; }
    string Name { get; }
    DateTime DateOfBirth { get; }
    BloodType BloodType { get; }
}

public enum BloodType { A, B, AB, O }
public enum Condition { Stable, Critical, Recovering }

#region Priority Queue

public class PriorityQueue<T> where T : IPatient
{
    private readonly SortedDictionary<int, Queue<T>> _queues = new();

    public void Enqueue(T patient, int priority)
    {
        if (priority < 1 || priority > 5)
            throw new ArgumentOutOfRangeException(nameof(priority),
                "Priority must be 1–5.");

        if (!_queues.ContainsKey(priority))
            _queues[priority] = new Queue<T>();

        _queues[priority].Enqueue(patient);
    }

    public T Dequeue()
    {
        foreach (var kv in _queues)
        {
            if (kv.Value.Count > 0)
                return kv.Value.Dequeue();
        }
        throw new InvalidOperationException("Queue empty.");
    }

    public T Peek()
    {
        foreach (var kv in _queues)
        {
            if (kv.Value.Count > 0)
                return kv.Value.Peek();
        }
        throw new InvalidOperationException("Queue empty.");
    }

    public int GetCountByPriority(int priority)
    {
        return _queues.ContainsKey(priority)
            ? _queues[priority].Count
            : 0;
    }
}

#endregion

#region Medical Record

public class MedicalRecord<T> where T : IPatient
{
    private readonly T _patient;
    private readonly List<(DateTime date, string diagnosis)> _diagnoses = new();
    private readonly Dictionary<DateTime, string> _treatments = new();

    public MedicalRecord(T patient)
    {
        _patient = patient;
    }

    public void AddDiagnosis(string diagnosis, DateTime date)
    {
        _diagnoses.Add((date, diagnosis));
    }

    public void AddTreatment(string treatment, DateTime date)
    {
        _treatments[date] = treatment;
    }

    public IEnumerable<KeyValuePair<DateTime, string>>
        GetTreatmentHistory()
    {
        return _treatments
            .OrderBy(t => t.Key);
    }
}

#endregion

#region Patient Types

public class PediatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public string GuardianName { get; set; }
    public double Weight { get; set; }
}

public class GeriatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public List<string> ChronicConditions { get; } = new();
    public int MobilityScore { get; set; }
}

#endregion

#region Medication System

public class MedicationSystem<T> where T : IPatient
{
    private readonly Dictionary<T, List<(string med, DateTime time)>>
        _medications = new();

    public void PrescribeMedication(
        T patient,
        string medication,
        Func<T, bool> dosageValidator)
    {
        if (!dosageValidator(patient))
            throw new InvalidOperationException(
                "Dosage validation failed.");

        if (!_medications.ContainsKey(patient))
            _medications[patient] = new List<(string, DateTime)>();

        _medications[patient].Add((medication, DateTime.Now));

        Console.WriteLine(
            $"Medication {medication} prescribed to {patient.Name}");
    }

    public bool CheckInteractions(T patient, string newMedication)
    {
        if (!_medications.ContainsKey(patient))
            return false;

        return _medications[patient]
            .Any(m => string.Equals(m.med,
                newMedication,
                StringComparison.OrdinalIgnoreCase));
    }
}

#endregion

#region Test Scenario

class Program
{
    static void Main()
    {
        var queue = new PriorityQueue<IPatient>();

        var p1 = new PediatricPatient
        {
            PatientId = 1,
            Name = "Child A",
            DateOfBirth = DateTime.Now.AddYears(-8),
            BloodType = BloodType.A,
            GuardianName = "Parent A",
            Weight = 25
        };

        var p2 = new PediatricPatient
        {
            PatientId = 2,
            Name = "Child B",
            DateOfBirth = DateTime.Now.AddYears(-10),
            BloodType = BloodType.O,
            GuardianName = "Parent B",
            Weight = 30
        };

        var g1 = new GeriatricPatient
        {
            PatientId = 3,
            Name = "Senior A",
            DateOfBirth = DateTime.Now.AddYears(-75),
            BloodType = BloodType.B,
            MobilityScore = 4
        };

        var g2 = new GeriatricPatient
        {
            PatientId = 4,
            Name = "Senior B",
            DateOfBirth = DateTime.Now.AddYears(-80),
            BloodType = BloodType.AB,
            MobilityScore = 6
        };

        // Priority queue test
        queue.Enqueue(p1, 2);
        queue.Enqueue(g1, 1);
        queue.Enqueue(p2, 3);
        queue.Enqueue(g2, 2);

        Console.WriteLine("Next patient: " + queue.Peek().Name);

        Console.WriteLine("\nProcessing patients:");
        while (true)
        {
            try
            {
                Console.WriteLine(queue.Dequeue().Name);
            }
            catch { break; }
        }

        // Medical record
        var record = new MedicalRecord<PediatricPatient>(p1);
        record.AddDiagnosis("Flu", DateTime.Today.AddDays(-3));
        record.AddTreatment("Antiviral", DateTime.Today.AddDays(-2));

        Console.WriteLine("\nTreatment history:");
        foreach (var t in record.GetTreatmentHistory())
            Console.WriteLine($"{t.Key:d} - {t.Value}");

        // Medication validation
        var medSystem = new MedicationSystem<IPatient>();

        medSystem.PrescribeMedication(
            p1,
            "Paracetamol",
            patient => patient is PediatricPatient ped &&
                       ped.Weight >= 20);

        medSystem.PrescribeMedication(
            g1,
            "Aspirin",
            patient => patient is GeriatricPatient ger &&
                       ger.MobilityScore > 3);

        Console.WriteLine(
            "\nInteraction check (Aspirin again): " +
            medSystem.CheckInteractions(g1, "Aspirin"));
    }
}

#endregion
