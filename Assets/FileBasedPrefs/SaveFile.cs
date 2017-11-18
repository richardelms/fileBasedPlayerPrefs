﻿using System;
using System.Linq;
[Serializable]
public class SaveFile
{
    public StringItem[] StringData = new StringItem[0];
    public IntItem[] IntData = new IntItem[0];
    public FloatItem[] FloatData = new FloatItem[0];

    [Serializable]
    public class StringItem
    {
        public string Key;
        public string Value;
        public StringItem(string K, string V)
        {
            Key = K;
            Value = V;
        }
    }

    [Serializable]
    public class IntItem
    {
        public string Key;
        public int Value;
        public IntItem(string K, int V)
        {
            Key = K;
            Value = V;
        }
    }

    [Serializable]
    public class FloatItem
    {
        public string Key;
        public float Value;
        public FloatItem(string K, float V)
        {
            Key = K;
            Value = V;
        }
    }

    public string GetStringFromKey(string key, string defaultValue)
    {
        for (int i = 0; i < StringData.Length; i++)
        {
            if(StringData[i].Key.Equals(key))
            {
                return StringData[i].Value;
            }
        }
        return defaultValue;
    }

    public int GetIntFromKey(string key, int defaultValue)
    {
        for (int i = 0; i < IntData.Length; i++)
        {
            if (IntData[i].Key.Equals(key))
            {
                return IntData[i].Value;
            }
        }
        return defaultValue;
    }

    public float GetFloatFromKey(string key, float defaultValue)
    {
        for (int i = 0; i < FloatData.Length; i++)
        {
            if (FloatData[i].Key.Equals(key))
            {
                return FloatData[i].Value;
            }
        }
        return defaultValue;
    }

    public void UpdateOrAddData(string key, object value)
    {
        if (HasKey(key, value))
        {
            SetValueForExistingKey(key, value);
        }
        else
        {
            SetValueForNewKey(key, value);
        }
    }

    private void SetValueForNewKey(string key, object value)
    {
        if (value is string)
        {
            var dataAsList = StringData.ToList();
            dataAsList.Add(new StringItem(key, (string)value));
            StringData = dataAsList.ToArray();
        }
        if (value is int)
        {
            var dataAsList = IntData.ToList();
            dataAsList.Add(new IntItem(key, (int)value));
            IntData = dataAsList.ToArray();
        }
        if (value is float)
        {
            var dataAsList = FloatData.ToList();
            dataAsList.Add(new FloatItem(key, (float)value));
            FloatData = dataAsList.ToArray();
        }
    }



    private void SetValueForExistingKey(string key, object value)
    {
        
        if (value is string)
        {
            for (int i = 0; i < StringData.Length; i++)
            {
                if (StringData[i].Key.Equals(key))
                {
                    StringData[i].Value = (string)value;
                }
            }
        }
        if (value is int)
        {
            for (int i = 0; i < IntData.Length; i++)
            {
                if (IntData[i].Key.Equals(key))
                {
                    IntData[i].Value = (int)value;
                }
            }
        }
        if (value is float)
        {
            for (int i = 0; i < FloatData.Length; i++)
            {
                if (FloatData[i].Key.Equals(key))
                {
                    FloatData[i].Value = (float)value;
                }
            }
        }
    }

    public bool HasKey(string key, object value)
    {
        
        if (value is string)
        {
            for (int i = 0; i < StringData.Length; i++)
            {
                if(StringData[i].Key.Equals(key))
                {
                    return true;
                }
            }
        }

        if (value is int)
        {
            for (int i = 0; i < IntData.Length; i++)
            {
                if (IntData[i].Key.Equals(key))
                {
                    return true;
                }
            }
        }

        if (value is float)
        {
            for (int i = 0; i < FloatData.Length; i++)
            {
                if (FloatData[i].Key.Equals(key))
                {
                    return true;
                }
            }
        }

        return false;

    }

}