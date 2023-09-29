using System.ComponentModel.Design.Serialization;
using System.Security;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] a = new string[,]
            {
            //cot:0   1   2
                {"1","2","3" },//hang 0
                {"4","5","6" },// hang 1
                {"7","8","9" } //hang 2
            };
            int nguoiChoiHienTai=1;
            int soNhapVao = 1;
            bool ketThuc = false;
            while (!ketThuc)
            {
                Bang(a);
                Console.WriteLine("Nguoi choi {0}: Hay nhap so cua ban: ", nguoiChoiHienTai);
                string nhap = Console.ReadLine();
                bool kiemTraGiaTri=false;
                kiemTraGiaTri = int.TryParse(nhap, out soNhapVao) && soNhapVao >= 1 && soNhapVao <= 9 && KiemTraViTri(a, soNhapVao);
                while (!kiemTraGiaTri)
                {
                    Console.WriteLine("So ban nhap khong hop le. Hay nhap lai! ");
                }
                CapNhatBang(a, soNhapVao, nguoiChoiHienTai == 1 ? "o" : "x");
                if (KiemTraNguoiChienThang(a))
                {
                    Console.WriteLine("Nguoi choi {0} la nguoi chien thang!!!", nguoiChoiHienTai);
                    ketThuc = true;
                }else if (KiemTraBangDay(a))
                {
                    Console.WriteLine("Hoa");
                    ketThuc = true;
                }
                nguoiChoiHienTai = nguoiChoiHienTai == 1 ? 2 : 1;
            }
        }
        static void Bang(string[,] a)
        {
            Console.Clear();
            Console.WriteLine("{0}  |  {1}  |  {2}", a[0, 0], a[0, 1], a[0, 2]);
            Console.WriteLine("---+-----+---");
            Console.WriteLine("{0}  |  {1}  |  {2}", a[1, 0], a[1, 1], a[1, 2]);
            Console.WriteLine("---+-----+---");
            Console.WriteLine("{0}  |  {1}  |  {2}", a[2, 0], a[2, 1], a[2, 2]);
        }
        static bool KiemTraViTri(string[,] a, int soNhapVao)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (a[i, j] == soNhapVao.ToString())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static void CapNhatBang(string[,] a, int soNhapVao, string kiHieu)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (a[i, j] == soNhapVao.ToString())
                    {
                        a[i,j]=kiHieu;
                        return;
                    }
                }
            }
        }
        static bool KiemTraNguoiChienThang(string[,] a)
        {
            for(int i = 0; i < 3; i++)//kiem tra hang
            {
                if (a[i, 0] == a[i,1] && a[i, 0] == a[i, 2])
                {
                    return true;
                }
            }
            for(int j = 0; j < 3; j++)//kiem tra cot
            {
                if (a[0, j] == a[1,j] && a[0, j] == a[2, j])
                {
                    return true;
                }
            }
            //kiem tra duong cheo
            if ((a[0, 0] == a[1,1] && a[0, 0] == a[2,2]) || (a[0, 2] == a[1,1] && a[0, 2] == a[2, 0]))
            {
                return true;
            }
            return false;
        }
        static bool KiemTraBangDay(string[,] a)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (a[i,j]!="o" && a[i, j] != "x")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
   
}