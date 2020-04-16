import { Component } from '@angular/core';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: []
})
export class AppComponent {

  selectedDate: Date = new Date();
  displayMonth: Date = new Date(this.selectedDate.getFullYear(), this.selectedDate.getMonth());
  displayMonthStr: string;
  datesForMonth: number[][] = [];
  timesForDates: string[][] = [];

  constructor(private datePipe: DatePipe) {
    this.displayMonthStr = datePipe.transform(this.displayMonth, 'MMMM, yyyy');

    this.fillDatesFor(this.displayMonth.getFullYear(), this.displayMonth.getMonth());
    this.fillTimesForDates(this.displayMonth.getMonth());
  }

  onPlusDate() {
    this.displayMonth.setMonth(this.displayMonth.getMonth() + 1);
    this.displayMonthStr = this.datePipe.transform(this.displayMonth, 'MMMM, yyyy');

    this.fillDatesFor(this.displayMonth.getFullYear(), this.displayMonth.getMonth());
    this.fillTimesForDates(this.displayMonth.getMonth());
  }

  onMinusDate() {
    this.displayMonth.setMonth(this.displayMonth.getMonth() - 1);
    this.displayMonthStr = this.datePipe.transform(this.displayMonth, 'MMMM, yyyy');

    this.fillDatesFor(this.displayMonth.getFullYear(), this.displayMonth.getMonth());
    this.fillTimesForDates(this.displayMonth.getMonth());
  }

  // month 0 indexed
  fillDatesFor(year: number, month: number) {
    var firstDayDate = new Date(year, month, 1);
    var lastDayDate = new Date(year, month + 1, 0);

    var daysInMonth = lastDayDate.getDate();
    var firstDay0Sun = firstDayDate.getDay();
    var firstDay = firstDay0Sun == 0 ? 7 : firstDay0Sun;

    this.datesForMonth.splice(0, this.datesForMonth.length);
    var dayCumulator = 1;

    var weekDays = [];
    for (let index = 1; index < 8; index++) { // first week
      if (firstDay > index) {
        weekDays.push(null);
      } else {
        weekDays.push(dayCumulator++);
      }
    }
    this.datesForMonth.push(weekDays);

    for (let index = 2; index < 7; index++) { // weeks post first week
      weekDays = [];
      for (let index = 1; index < 8; index++) { // days
        if (dayCumulator <= daysInMonth) {
          weekDays.push(dayCumulator++);
        } else {
          break;
        }
      }
      this.datesForMonth.push(weekDays);
    }
  }

  fillTimesForDates(month: number) {
    var monthShortName = this.getMonthShortNameFor(month);

    if (this.timeSource[monthShortName]) {
      var timesForMonth = this.timeSource[monthShortName].slice(0, this.timeSource[monthShortName].length);
    }

    this.timesForDates.splice(0, this.timesForDates.length);
    this.timesForDates = timesForMonth ?? [];
  }

  getMonthShortNameFor(month: number): string {
    switch (month) {
      case 0:
        return "jan";
      case 1:
        return "feb";
      case 2:
        return "mar";
      case 3:
        return "apr";
      case 4:
        return "may";
      case 5:
        return "jun";
      case 6:
        return "jul";
      case 7:
        return "aug";
      case 8:
        return "sep";
      case 9:
        return "oct";
      case 10:
        return "nov";
      case 11:
        return "dec";
      default:
        return "n/a";
    }
  }

  private timeSource = {
    "jan": [
      ["1 - 3", "5:00", "6:22", "12:15", "3:36", "4:28", "6:06", "7:21"],
      ["4 - 6", "5:02", "6:24", "12:17", "3:38", "4:31", "6:08", "7:23"],
      ["7 - 8", "5:03", "6:25", "12:18", "3:39", "4:32", "6:09", "7:24"],
      ["9 - 10", "5:04", "6:25", "12:19", "3:40", "4:33", "6:10", "7:25"],
      ["11 - 12", "5:05", "6:26", "12:20", "3:41", "4:34", "6:11", "7:26"],
      ["13-15", "5:06", "6:27", "12:20", "3:42", "4:34", "6:12", "7:27"],
      ["16 - 17", "5:07", "6:28", "12:22", "3:44", "4:36", "6:14", "7:28"],
      ["18 - 20", "5:08", "6:28", "12:22", "3:44", "4:36", "6:15", "7:29"],
      ["21 - 25", "5:09", "6:29", "12:23", "3:45", "4:38", "6:16", "7:30"],
      ["26 - 29", "5:10", "6:30", "12:24", "3:47", "4:40", "6:18", "7:31"],
      ["30 - 31", "5:11", "6:30", "12:25", "3:47", "4:42", "6:19", "7:32"]
    ],
    "feb": [
      ["1 - 6", "5:11", "6:30", "12:26", "3:48", "4:42", "6:20", "7:32"],
      ["7 - 12", "5:11", "6:29", "12:26", "3:48", "4:43", "6:21", "7:33"],
      ["13 - 17", "5:11", "6:28", "12:26", "3:47", "4:44", "6:22", "7:33"],
      ["18 - 24", "5:11", "6:27", "12:26", "3:47", "4:44", "6:22", "7:33"],
      ["25 - 29", "5:09", "6:25", "12:25", "3:45", "4:43", "6:23", "7:33"]
    ],
    "mar": [
      ["1 - 4", "5:08", "6:24", "12:24", "3:42", "4:43", "6:22", "7:32"],
      ["5 - 9", "5:06", "6:22", "12:23", "3:41", "4:42", "6:22", "7:32"],
      ["10 - 13", "5:04", "6:20", "12:22", "3:38", "4:41", "6:22", "7:32"],
      ["14 - 18", "5:03", "6:18", "12:21", "3:35", "4:40", "6:22", "7:31"],
      ["19 - 20", "5:01", "6:16", "12:20", "3:33", "4:38", "6:22", "7:31"],
      ["21 - 24", "4:59", "6:14", "12:19", "3:31", "4:37", "6:21", "7:31"],
      ["25 - 27", "4:57", "6:13", "12:18", "3:28", "4:36", "6:21", "7:31"],
      ["28 - 30", "4:56", "6:11", "12:17", "3:25", "4:34", "6:21", "7:30"],
      ["31", "4:54", "6:10", "12:16", "3:22", "4:33", "6:20", "7:30"]
    ],
    "apr": [
      ["1 - 2", "4:53", "6:10", "12:16", "3:21", "4:33", "6:20", "7:30"],
      ["3 - 5", "4:52", "6:08", "12:15", "3:19", "4:32", "6:20", "7:30"],
      ["6 - 11", "4:50", "6:07", "12:14", "3:16", "4:30", "6:19", "7:30"],
      ["12 - 14", "4:48", "6:05", "12:13", "3:17", "4:30", "6:19", "7:30"],
      ["15 - 18", "4:46", "6:03", "12:12", "3:19", "4:31", "6:19", "7:30"],
      ["19 - 24", "4:44", "6:01", "12:11", "3:21", "4:31", "6:19", "7:30"],
      ["25 - 29", "4:41", "5:59", "12:10", "3:23", "4:31", "6:19", "7:30"],
      ["30", "4:39", "5:57", "12:09", "3:25", "4:32", "6:19", "7:31"]
    ],
    "may": [
      ["1 - 3", "4:38", "5:57", "12:09", "3:26", "4:32", "6:19", "7:31"],
      ["4 - 8", "4:37", "5:57", "12:09", "3:27", "4:33", "6:19", "7:32"],
      ["9 - 14", "4:35", "5:55", "12:08", "3:28", "4:34", "6:20", "7:33"],
      ["15 - 19", "4:34", "5:54", "12:08", "3:30", "4:34", "6:20", "7:34"],
      ["20 - 25", "4:33", "5:54", "12:08", "3:32", "4:35", "6:21", "7:36"],
      ["26 - 28", "4:32", "5:53", "12:09", "3:34", "4:37", "6:22", "7:38"],
      ["29 - 31", "4:32", "5:54", "12:09", "3:35", "4:38", "6:23", "7:39"]
    ],
    "jun": [
      ["1 - 6", "4:32", "5:54", "12:10", "3:36", "4:38", "6:24", "7:40"],
      ["7 - 10", "4:31", "5:54", "12:11", "3:38", "4:40", "6:25", "7:42"],
      ["11 - 14", "4:31", "5:55", "12:11", "3:39", "4:41", "6:26", "7:43"],
      ["15 - 17", "4:32", "5:55", "12:12", "3:39", "4:41", "6:27", "7:44"],
      ["18 - 20", "4:32", "5:56", "12:13", "3:40", "4:42", "6:28", "7:44"],
      ["21 - 25", "4:33", "5:57", "12:14", "3:41", "4:43", "6:29", "7:45"],
      ["26 - 30", "4:34", "5:58", "12:15", "3:42", "4:44", "6:30", "7:47"]
    ],
    "jul": [
      ["1 - 6", "4:35", "5:59", "12:16", "3:43", "4:45", "6:31", "7:47"],
      ["7 - 10", "4:37", "6:00", "12:17", "3:44", "4:46", "6:32", "7:48"],
      ["11 - 18", "4:39", "6:01", "12:17", "3:44", "4:46", "6:32", "7:48"],
      ["19 - 23", "4:41", "6:03", "12:18", "3:43", "4:46", "6:32", "7:47"],
      ["24 - 29", "4:42", "6:03", "12:18", "3:42", "4:45", "6:31", "7:46"],
      ["30 - 31", "4:43", "6:04", "12:18", "3:40", "4:44", "6:31", "7:44"]
    ],
    "aug": [
      ["1 - 4", "4:44", "6:04", "12:18", "3:39", "4:44", "6:31", "7:44"],
      ["5 - 9", "4:45", "6:05", "12:18", "3:38", "4:43", "6:29", "7:43"],
      ["10 - 14", "4:45", "6:04", "12:17", "3:35", "4:41", "6:27", "7:40"],
      ["15 - 19", "4:46", "6:04", "12:16", "3:31", "4:39", "6:26", "7:38"],
      ["20 - 23", "4:46", "6:04", "12:15", "3:28", "4:37", "6:24", "7:36"],
      ["24 - 26", "4:46", "6:04", "12:14", "3:25", "4:34", "6:22", "7:34"],
      ["27 - 29", "4:47", "6:04", "12:13", "3:22", "4:33", "6:21", "7:32"],
      ["30 - 31", "4:47", "6:03", "12:13", "3:19", "4:31", "6:19", "7:30"]
    ]
  };
}
