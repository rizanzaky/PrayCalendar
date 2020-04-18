import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PrayerTimesService {

  constructor(private httpClient: HttpClient ) { }

  getMonthlyPrayerTimes() {
    var x = this.httpClient.get('./assets/prayer-times-month.json');
    return x;
  }
}
