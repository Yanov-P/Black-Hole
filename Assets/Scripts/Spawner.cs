using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ICopyable m_Copy;
    public Enemy SpawnEnemy(Enemy prototype)
    {
            m_Copy = prototype.Copy();
            return (Enemy)m_Copy;
    }
}
