using System;
using System.Collections.Generic;
using System.Reflection;

public class EntityTracker
{
    public List<AuditEntry> TrackChanges<T>(T oldObj, T newObj)
    {
        var auditList = new List<AuditEntry>();

        var props = typeof(T).GetProperties();

        foreach (PropertyInfo prop in props)
        {
            var oldVal = prop.GetValue(oldObj)?.ToString();
            var newVal = prop.GetValue(newObj)?.ToString();

            if (oldVal != newVal)
            {
                auditList.Add(new AuditEntry
                {
                    PropertyName = prop.Name,
                    OldValue = oldVal,
                    NewValue = newVal
                });
            }
        }

        return auditList;
    }
}
