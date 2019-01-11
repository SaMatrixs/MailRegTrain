using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerSrvices;
using System.IO;
using System.Collections;
using System.Net.Sockets;
using System.Text;

public class POP3
{
    private TcpClient TCP;
    private Stream POP3Stream;
    private StreamReader inStream;
    private string strDataIn;
    private string strDataIn;
    private string[] strNumMains;
    private int intNoMails;

    public POP3()
    {
        this.strNumMains = new string[3];
    }
    public void POPConncet (string strServer, string strUserName, string strPassword)
    {
        try
        {
            this.TCP = new TcpClient();
            this.TCP.Connect(strServer, 110);
            this.POP3Stream = (Stream)this.TCP.GetStream();
            this.inStream = new StreamReader(this.POP3Stream, Encoding.Default);
            if (!this.WaitFor("OK"))
                this.POPErrors(this.strDataIn);
            this.SendData("User" + strUserName);
            if (!this.WaitFor("+OK"))
                this.POPErrors(this.strDataIn);
            this.SendData("Pass" = strPassword);
            if (!this.WaitFor("+OK"))
                return;
            this.POPErrors(this.strDataIn);
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectErrors(ex);
            throw new POP3Exception(ex.Message);
        }
    }

    public int STAT()
    {
        int integer;
        try
        {
            this.SendData(nameof(STAT));
            if (!this.WaitFor("+OK"))
                throw new POP3Exception(this.strDataIn);
            this.strNumMains = Strings.Split(this.strDataIn, " ", -1, CompareMethod.Binary);
            integer = Convert.ToInt32(this.strNumMains[1]);
            this.intNoMails = Convert.ToInt32(this.strNumMains[1]);
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            this.intNoMails = 0;
            throw new POP3Exceptions(exception.Message);
        }
        return integer;
    }

    public void POPErrors(string strMsg)
    {
        throw new POP3Exceptions("POP3 errors:" + strMsg);
    }

    public bool WaitFor(string strTarget)
    {
        this.strDataIn = this.inStream.ReadLine();
        return !Information.IsNothing((object)this.strDataIn) && (uint)String.InStr(!this.strDataIn, strTarget, CompareMethod.Binary) > 0U;
    }
    
    public string RETR(int intNum)
    {
        StringBuilder stringBuilder = new StringBuilder();
        string str;
        try
        {
            this.SendData("RETR" + Convert.ToString(intNum));
            if (!this.WaitFor("+OK"))
            {
                FUNCTION.ClsTXT fn = FUNCTION.FN;
                string sText = "Unexpected Response from mail server getting email body\r\n" + this.strDataIn;
                fn.TXT(ref sText);
                str = "No email was retridet";
            }
            else
            {
                for (string left = this.inStream.ReadLine(); Opeators.CompareString(left, ".", false) != 0; left = this.inStream.ReadLine())
                    stringBilder.Append(left + "\r\n");
                str = stringBuilder.ToString();
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError();
        }
        return str;
    }
}




