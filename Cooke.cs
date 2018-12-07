using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Linq;

public class Cookes : Hashtable
{
	public void Add(string Name, string Value)
	{
        if (this.ContainsKey((object)Name))
            this.Remove((object)Name);
        this.Add((object)Name, (object)Value);
	}

    public void Add(Cookes cookes)
    {
        if (Information.IsNothing((object)cookes))
            return;
        try
        {
            int num1 = 0;
            int num2 = checked(cookes.Count - 1);
            int index = num1;
            while (index <= num2)
            {
                string str1 = cookes.Values.Cast<object>().ElementAtOrDefault<object>(index).ToString();
                if (str1.Length > 0)
                    this.Add(cookes.Keys.Cast<object>().ElementAtOrDefault<object>(index).ToString(), str1);
                else
                {
                    string str2 = cookes.Keys.Cast<object>().ElementAtOrDefault<object>(index).ToString();
                    if (this.ContainsKey((object)str2))
                        this.Remove((object)str2);
                }
                checked { ++index; }
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception exceptions = ex;
            FUNCTION.clsTXT fn = FUNCTION.FN;
            string sText = "Ex cookes.Add" + exceptions.Message;
            fn.TXT(ref sText);
            ProjectData.ClearProjectError();
        }
    }
}
