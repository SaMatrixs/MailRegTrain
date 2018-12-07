using System;
using Microsoft.VisualBasic
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
}




