using System;

public class HumanTimeFormat{
  public static string formatDuration(int seconds){
    DateTime date = DateTime.Now;
    var span =  date.AddMilliseconds(-date.Millisecond).AddSeconds(seconds) - date.AddMilliseconds(-date.Millisecond);
    return string.Format("{0}{1}{2}{3}{4}{5}", 
                         (span.Days/365>0?string.Format("{0} year{1}", span.Days/365, (span.Days/365==1?"":"s")):""),
                         (span.Days%365>0?string.Format("{0}{1} day{2}", (span.Days/365>0?(span.Seconds==0&&span.Minutes==0&&span.Hours==0?" and ":", "):""), span.Days%365, (span.Days%365==1?"":"s")):""),
                         (span.Hours>0?string.Format("{0}{1} hour{2}", ((span.Days%365>0||span.Days/365>0)?(span.Seconds==0&&span.Minutes==0?" and ":", "):""), span.Hours, (span.Hours==1?"":"s")):""),
                         (span.Minutes>0?string.Format("{0}{1} minute{2}", ((span.Hours>0||span.Days%365>0||span.Days/365>0)?(span.Seconds==0?" and ":", "):""), span.Minutes, (span.Minutes==1?"":"s")):""),
                         (span.Seconds>0?string.Format("{0}{1} second{2}",((span.Hours>0||span.Minutes>0||span.Days%365>0||span.Days/365>0)?" and ":""),span.Seconds, (span.Seconds==1?"":"s")):""),
                         (seconds==0?"now":""));
  }
}