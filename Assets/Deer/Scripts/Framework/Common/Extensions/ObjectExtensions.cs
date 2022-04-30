// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2022-04-16 21-38-00  
//修改作者 : 杜鑫 
//修改时间 : 2022-04-16 21-38-00  
//版 本 : 0.1 
// ===============================================
using System;

public static class ObjectExtensions
{
	/// <summary>
	/// 对象如果为Null，抛出异常
	/// </summary>
	/// <param name="o"></param>
	/// <param name="message">异常消息</param>
	public static void ThrowIfNull(this object o, string message)
	{
		if (o == null) throw new NullReferenceException(message);
	}
}