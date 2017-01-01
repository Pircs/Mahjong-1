﻿using UnityEngine;
using System.Collections;
using System;

public class MyPlayer {

    #region 单例

    private static MyPlayer _Instance = new MyPlayer();

    public static MyPlayer Instance
    {
        get
        {
            return _Instance;
        }
    }

    #endregion

    /// <summary>
    /// 手牌List
    /// </summary>
    private int[] brands = new int[20];
    /// <summary>
    /// 手牌大小
    /// </summary>
    private int size = 0;
    /// <summary>
    /// 特殊操作牌
    /// </summary>
    private int[] OperationBrnads = new int[20];

    /// <summary>
    /// 碰牌记录
    /// </summary>
    private int[] peng = new int[2];

    /// <summary>
    /// 杠牌记录
    /// </summary>
    private int[] gang = new int[3];

    /// <summary>
    /// 吃牌记录
    /// </summary>
    private int[] chi = new int[4];

    /// <summary>
    /// 获得手牌数目
    /// </summary>
    /// <returns>数目</returns>
    public int getSize()
    {
        return size;
    }

    /// <summary>
    /// 检测能否胡
    /// </summary>
    /// <param name="num">检测牌</param>
    /// <returns>能否胡</returns>
    public bool isHu(int num)
    {
        return false;
    }

    /// <summary>
    /// 检测能否听
    /// </summary>
    /// <returns>能否听</returns>
    public bool isTing()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                int num = i * 10 + j;

                Ting(num);
            }
        }
        return false;
    }

    private bool Ting(int num)
    {
        int[] T = brands;
        T[size] = num;
        Array.Sort(T);
        bool bo = false;


        for (int i = 0; i <= size; i++)
        {
            if (T[i] == 0 || T[i] == 8 || T[i] == 10 || T[i] == 18 || T[i] == 20 || T[i] == 28 || T[i] == 34)
            {
                bo = true;
            }
            if (i <= size - 2)
            {
                if (T[i] == T[i + 1] && T[i + 1] == T[i + 2])
                {
                    bo = true;
                }
            }
        }
    }

    /// <summary>
    /// 检测是否能碰
    /// </summary>
    /// <param name="num">检测牌数</param>
    /// <returns>是否能碰</returns>
    public bool isPeng(int num)
    {
        int t = 0;
        for (int i = 0; i < size; i++)
        {
            if (brands[i] == num)
            {
                peng[t] = i;
                t++;
            }
            if (t == 2) return true;
        }
        return false;
    }

    /// <summary>
    /// 检测是否能杠
    /// </summary>
    /// <param name="num">检测牌</param>
    /// <returns>是否能杠</returns>
    public bool isGang(int num)
    {
        int t = 0;
        for (int i = 0; i < size; i++)
        {
            if (brands[i] == num)
            {
                gang[t] = i;
                t++;
            }
            if (t == 3) return true;
        }
        return false;
    }

    /// <summary>
    /// 检测是否能吃
    /// </summary>
    /// <param name="num">检测牌</param>
    /// <returns>是否能吃</returns>
    public bool isChi(int num)
    {
        bool p = false;
        for (int i = 0; i < 4; i++)
        {
            chi[i] = -1;
        }
        for (int i = 0; i < size; i++)
        {
            if (brands[i] == num - 2)
                chi[0] = i;
            if (brands[i] == num - 1)
            {
                chi[1] = i;
                if (chi[0] != -1) p = true;
            }
            if (brands[i] == num + 1)
            {
                chi[2] = i;
                if (chi[1] != -1) p = true;
            }
            if (brands[i] == num + 2)
            {
                chi[3] = i;
                if (chi[1] != -1) p = true;
            }
        }
        return p;
    }

    /// <summary>
    /// 排序手牌
    /// </summary>
    public void Sort()
    {
        Array.Sort(brands);
    }

    /// <summary>
    /// 获得最后的牌
    /// </summary>
    /// <returns></returns>
    public int GetEnd()
    {
        return brands[size - 1];
    }

    /// <summary>
    /// 获得指定牌
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public int Get(int num)
    {
        return brands[num];
    }

    /// <summary>
    /// 添加手牌
    /// </summary>
    /// <param name="num"></param>
    public void Add(int num)
    {
        brands[size] = num;
        size++;
    }

    /// <summary>
    /// 删除手牌
    /// </summary>
    /// <param name="num"></param>
    public void Remove(int pos)
    {
        brands[pos] = brands[size];
        size--;
    }

}
