import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PrayerTimesService {

  constructor(private httpClient: HttpClient ) { }

  async getMonthlyPrayerTimesAsync() {
    var x = await this.httpClient.get('./assets/prayer-times-month.json').toPromise();
    return x;
  }
}
