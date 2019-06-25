using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop_weapon_manager : MonoBehaviour
{
    #region Singleton
    public static Shop_weapon_manager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] List<Shop_weapon_record> records;
    [SerializeField] Shop_weapon_stats stats;

    void Start()
    {
    }

    public void Awaken()
    {
        foreach (Shop_weapon_record g in records)
            g.gameObject.SetActive(true);

    }
    public void Close()
    {
        foreach (Shop_weapon_record g in records)
            g.gameObject.SetActive(false);
    }
    public void showStatsOfRecord(int index)
    {
        foreach (Shop_weapon_record g in records.Where(g => g.Index != index))
            g.ShowMore.gameObject.SetActive(false);

        stats.gameObject.SetActive(true);

        
    }
    public void hideStatsOfRecord(int index)
    {
        foreach (Shop_weapon_record g in records.Where(g => g.Index != index))
            g.ShowMore.gameObject.SetActive(true);

        stats.gameObject.SetActive(false);
    }

}
