using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.ViewModels
{
	public class TimelineChartViewModel : BaseViewModel
	{
		public ObservableQueue<DatePoint> Points { get; private set; } = new ObservableQueue<DatePoint>();

		public DateTime Now { get; private set; }
		//-------------------------------------------------------------------------------gilbert start 2021.09.05
		public double MaxSecond { get; private set; } =  MainViewModel.ConfigClass.MaxValue_Chart ;//35

		public long counter = 0;
		//-------------------------------------------------------------------------------gilbert end
		public void Add(double value)
		{
			var now = DateTime.Now;
			//-------------------------------------------------------------------------------gilbert start 2021.09.05
			// TODO: 第2頁 下拉選單
			MaxSecond = MainViewModel.ConfigClass.MaxValue_Chart;
			
			//-------------------------------------------------------------------------------gilbert end
			while (Points.Count > 0 && (now - Points.Peek().Time).TotalSeconds > MaxSecond)
			{
				Points.Dequeue();
			}
			
			// Confirm radio_button is switch or not, 確認radio button是否有從分(min)切換到時(hour)或是日(day)
			if (MainViewModel.ConfigClass.MaxValue_Chart != MainViewModel.ConfigClass.local_chartUnit)
			{
				Points.Clear();
				for (long i= (long)MainViewModel.ConfigClass.MaxValue_Chart;   0< i;  i--)
				{	 
					Points.Enqueue(
						new DatePoint(
							DateTimeOffset.FromUnixTimeSeconds(DateTimeOffset.Now.ToUnixTimeSeconds() - i).DateTime.ToLocalTime(), 
							counter
							//每次根據對應的時間(ex:每秒)去query一筆DB,一筆資料需要約0.08sec,所以一張圖所需時間0.08*1020(pixel)/60sec == 1.36 min 等太久了,稍晚解決，先用counter代替
							//MainViewModel.ConfigClass.gMongoPickDBmodel.Get_petCurAmount_perUnitTime1( DateTimeOffset.Now.ToUnixTimeSeconds() - i ,1,1,"","") 
							)
						);
					if(counter < MainViewModel.ConfigClass.MaxValue_Height)
						counter += 1;
					MainViewModel.ConfigClass.local_chartUnit = MainViewModel.ConfigClass.MaxValue_Chart;
				}
			}//end of if(MainViewModel....
			else
			{
				Points.Enqueue(new DatePoint(now, value));
			}
			
			
			Now = now;
			RaisePropertyChanged("Now");
		}
	}
}
