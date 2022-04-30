// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2022-04-16 21-41-25  
//修改作者 : 杜鑫 
//修改时间 : 2022-04-16 21-41-25  
//版 本 : 0.1 
// ===============================================
using System;
using System.Collections.Generic;

public class DictionaryEx<TKey, TValue> : Dictionary<TKey, TValue>    
{
	public new TValue this[TKey indexKey]
	{
		set { base[indexKey] = value; }
		get
		{
			try
			{
				return base[indexKey];
			}
			catch (Exception)
			{
				return default(TValue);
			}
		}
	}
}