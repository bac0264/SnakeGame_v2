﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
public class SaveLoad : MonoBehaviour
{
    public static SaveLoad instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [Serializable]
    public class SaveData
    {
        public List<snakeHeadItem> shopList = new List<snakeHeadItem>();
        public List<snakeHeadItem> boughts = new List<snakeHeadItem>();
        public int currentSnake = 1;
    }
    [Serializable]
    public class SaveStar
    {
        public int star;
    }
    public void saving()
    {
        try
        {
            SaveData saveData = new SaveData();
            // Save Data
            saveData.shopList.Clear();
            saveData.boughts.Clear();
            for (int i = 0; i < ShopManager.instance.boughtList.Count; i++)
            {
                saveData.boughts.Add(ShopManager.instance.boughtList[i]);
            }
            for (int i = 0; i < ShopManager.instance.snakeHeadList.Count; i++)
            {
                saveData.shopList.Add(ShopManager.instance.snakeHeadList[i]);
            }
            saveData.currentSnake = ShopManager.instance.currentID;
            //
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(Application.persistentDataPath + "/shop.txt", FileMode.OpenOrCreate);
            bf.Serialize(fs, saveData);
            fs.Close();
        }
        catch (Exception e)
        {
            print(e);
        }
        print("saved data to " + Application.persistentDataPath + "/shop.txt");
    }
    public void loading()
    {
        Debug.Log(Application.persistentDataPath + "/shop.txt");
        if (File.Exists(Application.persistentDataPath + "/shop.txt"))
        {
            try
            {
                SaveData saveData = new SaveData();
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(Application.persistentDataPath + "/shop.txt", FileMode.Open);
                saveData = (SaveData)bf.Deserialize(fs);
                fs.Close();
                // do somthing
                ShopManager.instance.boughtList.Clear();
                ShopManager.instance.snakeHeadList.Clear();
                for (int i = 0; i < saveData.boughts.Count; i++)
                {
                    ShopManager.instance.boughtList.Add(saveData.boughts[i]);
                }
                for (int i = 0; i < saveData.shopList.Count; i++)
                {
                    ShopManager.instance.snakeHeadList.Add(saveData.shopList[i]);
                }
                ShopManager.instance.currentID = saveData.currentSnake;
            }
            catch (Exception e)
            {
                print(e);
            }
        }
    }
    public void savingStar()
    {
        try
        {
            SaveStar saveData = new SaveStar();
            // Save Data
            saveData.star = ScoreManager.instance.star;
            //
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(Application.persistentDataPath + "/star.txt", FileMode.OpenOrCreate);
            bf.Serialize(fs, saveData);
            fs.Close();
        }
        catch (Exception e)
        {
            print(e);
        }
        print("saved data to " + Application.persistentDataPath + "/star.txt");
    }
    public void loadingStar()
    {
        Debug.Log(Application.persistentDataPath + "/star.txt");
        if (File.Exists(Application.persistentDataPath + "/star.txt"))
        {
            try
            {
                SaveStar saveData = new SaveStar();
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(Application.persistentDataPath + "/star.txt", FileMode.Open);
                saveData = (SaveStar)bf.Deserialize(fs);
                fs.Close();
                // do somthing
                ScoreManager.instance.star = saveData.star;
                //Debug.Log
            }
            catch (Exception e)
            {
                print(e);
            }
        }
    }
    public void savingStar_2()
    {
        try
        {
            SaveStar saveData = new SaveStar();
            // Save Data
            saveData.star = ShopManager.instance.star;
            //
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(Application.persistentDataPath + "/star.txt", FileMode.OpenOrCreate);
            bf.Serialize(fs, saveData);
            fs.Close();
        }
        catch (Exception e)
        {
            print(e);
        }
        print("saved data to " + Application.persistentDataPath + "/star.txt");
    }
    public void loadingStar_2()
    {
        Debug.Log(Application.persistentDataPath + "/star.txt");
        if (File.Exists(Application.persistentDataPath + "/star.txt"))
        {
            try
            {
                SaveStar saveData = new SaveStar();
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(Application.persistentDataPath + "/star.txt", FileMode.Open);
                saveData = (SaveStar)bf.Deserialize(fs);
                fs.Close();
                // do somthing
                ShopManager.instance.star = saveData.star;
                Debug.Log("Star: " + ShopManager.instance.star);
                //Debug.Log
            }
            catch (Exception e)
            {
                print(e);
            }
        }
    }
}
