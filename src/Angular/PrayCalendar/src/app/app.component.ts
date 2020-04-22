import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { PrayerTimesService } from 'src/services/prayer-times.service';
import { DatetimeHelper } from 'src/helpers/datetime-herlper';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: []
})
export class AppComponent implements OnInit {

  selectedDate: Date = new Date();
  displayMonth: Date = new Date(this.selectedDate.getFullYear(), this.selectedDate.getMonth());
  displayMonthStr: string;
  datesForMonth: number[][] = [];
  timesForDates: string[][] = [];
  private prayerTimes: Object;
  private timeNow: Date
  timeNowHoursStr: string;
  timeNowMinsStr: string;
  isBlinked: boolean = false;
  timeNowAmPmStr: string;

  constructor(private prayerTimesService: PrayerTimesService, private datePipe: DatePipe) {
  }

  ngOnInit(): void {
    this.runClock();
    this.loadData();
  }

  private runClock() {
    this.updateTime();

    setInterval(() => {
      this.updateTime();
      this.isBlinked = !this.isBlinked;
    }, 1000);
  }

  private updateTime() {
    this.timeNow = new Date();
    this.timeNowHoursStr = this.datePipe.transform(this.timeNow, 'h');
    this.timeNowMinsStr = this.datePipe.transform(this.timeNow, 'mm');
    this.timeNowAmPmStr = this.datePipe.transform(this.timeNow, 'a');
  }

  private async loadData() {
    this.displayMonthStr = this.datePipe.transform(this.displayMonth, 'MMMM, yyyy');

    this.prayerTimes = await this.prayerTimesService.getMonthlyPrayerTimesAsync();

    this.fillDatesFor(this.displayMonth.getFullYear(), this.displayMonth.getMonth());
    this.fillPrayerTimesForDates(this.displayMonth.getMonth());
  }

  onPlusDate() {
    this.displayMonth.setMonth(this.displayMonth.getMonth() + 1);
    this.displayMonthStr = this.datePipe.transform(this.displayMonth, 'MMMM, yyyy');

    this.fillDatesFor(this.displayMonth.getFullYear(), this.displayMonth.getMonth());
    this.fillPrayerTimesForDates(this.displayMonth.getMonth());
  }

  onMinusDate() {
    this.displayMonth.setMonth(this.displayMonth.getMonth() - 1);
    this.displayMonthStr = this.datePipe.transform(this.displayMonth, 'MMMM, yyyy');

    this.fillDatesFor(this.displayMonth.getFullYear(), this.displayMonth.getMonth());
    this.fillPrayerTimesForDates(this.displayMonth.getMonth());
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
      if (weekDays.length > 0) {
        this.datesForMonth.push(weekDays);
      }
    }
  }

  fillPrayerTimesForDates(month: number) {
    var monthShortName = DatetimeHelper.getMonthShortNameFor(month);

    if (this.prayerTimes[monthShortName]) {
      var timesForMonth = this.prayerTimes[monthShortName].slice(0, this.prayerTimes[monthShortName].length);
    }

    this.timesForDates.splice(0, this.timesForDates.length);
    this.timesForDates = timesForMonth ?? [];
  }
}
