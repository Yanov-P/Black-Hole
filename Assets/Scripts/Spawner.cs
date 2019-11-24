using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ICopyable m_Copy;
    public static Dictionary<ICopyable, bool> _poolOfMeteors = new Dictionary<ICopyable, bool>();
    public Enemy SpawnEnemy(Enemy prototype)
    {
        if (_poolOfMeteors.Count < 10)
        {
            m_Copy = prototype.Copy();
            _poolOfMeteors.Add(m_Copy, true);
            return (Enemy)m_Copy;
        }
        else {
            m_Copy = _poolOfMeteors.First(kvp => kvp.Value == true).Key;
            _poolOfMeteors[m_Copy] = false;
            return (Enemy)m_Copy;
        };


    }

    
}
