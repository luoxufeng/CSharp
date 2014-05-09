using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using MvcApplication1.Models;

namespace MvcApplication1.Business
{
    public class TravelListBusiness
    {
        public TravelListViewModel GetGuidBookList(int currentIndex,int pageSize)
        {
            TravelListViewModel traveIList=new TravelListViewModel();
            int totalCount;
            traveIList.GuidBookList = GetBookData(currentIndex,pageSize,out   totalCount);
            traveIList.TotalCount = totalCount;
            traveIList.NavigationBar=new NavigationViewModel(currentIndex,pageSize,totalCount);
            return traveIList;
        }

        public List<GuideBook> GetBookData(int currentIndex,int pageSize,out int totalCount)
        {
            List<GuideBook> data=new List<GuideBook>();
            List<GuideBook> dataList = GetDataList();
            if (currentIndex <= 1)
            {
                data = dataList.GetRange(currentIndex, pageSize);
            }
            else
            {
                data = dataList.GetRange((currentIndex-1)*pageSize, pageSize);
            }
            

            totalCount = 100;
            return data;
        }

        public List<GuideBook> GetDataList()
        {
            List<GuideBook> guideBook = new List<GuideBook>();
            for (int i = 0; i < 100; i++)
            {
                GuideBook guide = new GuideBook()
                {
                    Name = "luo" + i,
                    Url = "http://www.test.com",
                    PicUrl = "http://www.pic.com",
                    DownLoadCount = i,
                    UpdateTime = DateTime.Now
                };
                guideBook.Add(guide);
            }
            return guideBook;
        }
        
    }
}