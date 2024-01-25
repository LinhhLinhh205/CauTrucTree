using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CauTrucTree
{
    class TNODE
    {
        public int Info;
        public TNODE Left;
        public TNODE Right;

        public TNODE(int x)
        {
            Info = x;
            Left = null;
            Right = null;
        }
    }
    class SearchBinaryTree
    {
        public TNODE Root;
        public SearchBinaryTree()
        {
            Root = null;
        }
        public void NLR(TNODE root)
        {
            if (root != null)
            {
                Console.Write($"{root.Info}-");
                NLR(root.Left);
                NLR(root.Right);
            }
        }
        public void LNR(TNODE root)
        {
            if (root != null)
            {
                LNR(root.Left);
                Console.Write($"{root.Info}");
                LNR(root.Right);

            }
        }
        public void LRN(TNODE root)
        {
            if (root != null)
            {
                LRN(root.Left);
                LRN(root.Right);
                Console.Write($"{root.Info}");
            }
        }
        public void ThemNode(ref TNODE root, int x)
        {
            if (root == null)
            {
                TNODE a = new TNODE(x);
                root = a;
            }
            else if (root.Info > x)
                ThemNode(ref root.Left, x);
            else if (root.Info < x)
                ThemNode(ref root.Right, x);
        }
        public void TaoCay()
        {
            Console.Write("Cho biet so nut trong cay:");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.Write("Nhap gia tri node thu " + i + ":");
                int x = int.Parse(Console.ReadLine());
                ThemNode(ref Root, x);
            }
        }
        public TNODE TimKiem(TNODE root, int x)
        {
            TNODE kq = null;
            if (root != null)
            {
                if (root.Info == x)
                    kq = root;
                else if (x < root.Info)
                    kq = TimKiem(root.Left, x);
                else
                    kq = TimKiem(root.Right, x);
            }
            return kq;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            SearchBinaryTree tree = new SearchBinaryTree();
            tree.TaoCay();
            Console.WriteLine("Ket qua duyet cay:");
            Console.Write("NLR:");
            tree.NLR(tree.Root);

            Console.Write("\nNhap gia tri nut can tim:");
            int x = int.Parse(Console.ReadLine());
            TNODE kq = tree.TimKiem(tree.Root, x);
            if (kq == null)
                Console.WriteLine($"{x} khong xuat hien trong cay");
            else
                Console.WriteLine($"{x} co xuat hien trong cay");
            Console.ReadLine();
        }
    }
}
