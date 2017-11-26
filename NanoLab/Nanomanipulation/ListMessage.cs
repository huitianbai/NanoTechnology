using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MultiMode.Nanomanipulation
{
    /// <summary>
    /// 列表信息类
    /// </summary>
    class ListMessage
    {

        /// <summary>
        /// 生成列表字符串内容函数
        /// </summary>
        /// <param name="greyImage"></param>
        /// <param name="points"></param>
        /// <param name="skeleton"></param>
        /// <param name="sampsInLine"></param>
        /// <param name="scanSize"></param>
        /// <returns></returns>
        public List<string> GetMessage(List<Nanowires> wires)
        {
            int l = wires.Count;
            List<string> listMessage = new List<string>(l);

            for (int i = 0; i < l; i++)
            {
                listMessage.Add(Convert.ToString(i + 1).PadRight(4, ' ') + wires[i].diameter.ToString("0.0").PadRight(7, ' ') +
                    wires[i].length.ToString("0.0").PadRight(8, ' ') + wires[i].division.ToString("0.0").PadRight(7, ' ') + wires[i].softOrStiff);
            }

            return listMessage;
        }

        /// <summary>
        /// 当判断软硬样条的阈值更新后刷新样条信息
        /// </summary>
        /// <param name="allWires"></param>
        /// <returns></returns>
        public void RefreshWires(List<Nanowires> allWires)
        {
            foreach (Nanowires wire in allWires)
            {
                wire.softOrStiff = wire.SoftOrStiffJudge(wire.points,wire.length,wire.diameter);
                wire.SetRotatingPointPosition();
            }
        }


        /// <summary>
        /// 指定项删除
        /// </summary>
        /// <param name="allWires"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public List<Nanowires> Delete(List<Nanowires> allWires, int[] indices)
        {
            for (int i = allWires.Count - 1; i >= 0; i--)
                if (Find(i, indices)) allWires.RemoveAt(i);
            return allWires;
        }

        /// <summary>
        /// 寻找指定索引
        /// </summary>
        /// <param name="index"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        private bool Find(int index, int[] indices)
        {
            for (int i = 0; i < indices.GetLength(0); i++)
            {
                if (index == indices[i])
                    return true;
            }
            return false;
        }
    }
}
