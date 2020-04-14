import { Component } from '@angular/core';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: []
})
export class AppComponent {

  selectedDate: Date = new Date();
  selectedDateStr: string;
  datesForMonth: number[][] = [];

  constructor(datePipe: DatePipe) {
    this.selectedDateStr = datePipe.transform(this.selectedDate, 'dd MMM yyyy');

    this.fillDatesFor(this.selectedDate.getFullYear(), this.selectedDate.getMonth());
  }

  // month 0 indexed
  fillDatesFor(year: number, month: number) {
    let firstDayDate = new Date(year, month, 1);
    let lastDayDate = new Date(year, month + 1, 0);

    let daysInMonth = lastDayDate.getDate();
    let firstDay0Sun = firstDayDate.getDay();
    let firstDay = firstDay0Sun == 0 ? 7 : firstDay0Sun;

    this.datesForMonth.slice(0, this.datesForMonth.length);
    let dayCumulator = 1;

    let weekDays = [];
    for (let index = 1; index < 8; index++) {
      if (firstDay == index) {
        weekDays.push(dayCumulator++);
      } else {
        weekDays.push(null);
      }
    }
    this.datesForMonth.push(weekDays);

    for (let index = 2; index < 7; index++) { // weeks
      let weekDays = [];
      for (let index = 1; index < 8; index++) { // days
        if (dayCumulator <= daysInMonth) {
          weekDays.push(dayCumulator++);
        } else {
          break;
        }
      }
      this.datesForMonth.push(weekDays);
    }

    // console.log("month = " + month);
    // console.log("year = " + year);
    // console.log("firstDayDate = " + firstDayDate);
    // console.log("lastDayDate = " + lastDayDate);
    // console.log("daysInMonth = " + daysInMonth);
    // console.log("firstDay = " + firstDay);
  }
}
