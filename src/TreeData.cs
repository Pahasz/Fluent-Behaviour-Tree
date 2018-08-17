using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentBehaviourTree
{
    /// <summary>
    /// Represents time. Used to pass time values to behaviour tree nodes.
    /// </summary>
    public class TreeData
    {
        public float deltaTime;
        public Dictionary<String, Object> dataMap = new Dictionary<string, object>();

        public TreeData()
        {

        }

        public void AddData(string key, Object data)
        {
            dataMap[key] = data;
        }

        public T GetData<T>(string key)
        {
            if(dataMap.ContainsKey(key))
                return (T)dataMap[key];
            
            return default(T);
        }
        
    }
}
