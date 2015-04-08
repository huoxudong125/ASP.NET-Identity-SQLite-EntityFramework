using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Mvc4WorkGps.Models
{
    public class WorkRecordModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("IMSI")]
        public string IMSI { get; set; }

        [DisplayName("定位时间")]
        public DateTime LocationDateTime { get; set; }//定位时间

        [DisplayName("定位类型")]
        public int LocationType { get; set; }//定位类型

        [DisplayName("维度")]
        public double Latitude { get; set; }//获取维度

        [DisplayName("经度")]
        public double Longitude { get; set; }//获取经度

        [DisplayName("是否有半径")]
        public bool HasRadius { get; set; } //判断是否有定位精度半径

        [DisplayName("精度半径")]
        public float Radius { get; set; } //获取定位精度半径，单位是米


        //获取省份信息
        [DisplayName("省份")]
        public string Province { get; set; }

        //获取城市信息
        [DisplayName("城市")]
        public string City { get; set; }

        //获取区县信息
        [DisplayName("区县")]
        public string District { get; set; }

        //获取定位地址
        [DisplayName("地址")]
        public string Address { get; set; }

        //工作内容
        [DisplayName("描述")]
        public string Description { get; set; }
    }
}