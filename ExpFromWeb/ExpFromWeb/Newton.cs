
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

[Serializable]
class Newton : IDeserializationCallback
{

    public Newton(int n = 67)
    {
        rozm = n;
        oblicz(rozm);
    }

    public ulong this[int n, int k]
    {
        get
        {
            return dn[n, k];
        }
    }

    [NonSerialized] private ulong[,] dn;
    private int rozm;

    private void oblicz(int r)
    {
        ++r;
        dn = new ulong[r, r];
        for (int n = 0; n < r; ++n)
        {
            dn[n, 0] = dn[n, n] = 1;
            for (int k = 1; k < n; ++k)
                dn[n, k] = checked(dn[n - 1, k - 1] + dn[n - 1, k]);
        }
    }

    void IDeserializationCallback.OnDeserialization(object sender)
    {
        Console.WriteLine("Newton_OnDeserialization - interface");
        oblicz(rozm);
    }

    [OnSerializing]
    private void Newton_OnSerializing(StreamingContext context)
    {
        Console.WriteLine("Newton_OnSerializing");
    }

    [OnSerialized]
    private void Newton_OnSerialized(StreamingContext context)
    {
        Console.WriteLine("Newton_OnSerialized");
    }

    [OnDeserializing]
    private void Newton_OnDeserializing(StreamingContext context)
    {
        Console.WriteLine("Newton_OnDeserializing");
    }

    [OnDeserialized]
    private void Newton_OnDeserialized(StreamingContext context)
    {
        Console.WriteLine("Newton_OnDeserialized");
        //oblicz(rozm);
    }

}

class Test
{

    public static void Main()
    {
        Newton n1 = new Newton();

        FileStream fs = new FileStream("newton_ser_soap.dat", FileMode.Create);
        SoapFormatter sf = new SoapFormatter();
        sf.Serialize(fs, n1);
        fs.Close();

        fs = new FileStream("newton_ser_soap.dat", FileMode.Open);
        Newton n2 = (Newton)sf.Deserialize(fs);
        fs.Close();

        Console.WriteLine(n1[60, 40]);
        Console.WriteLine(n2[60, 40]);
    }

}