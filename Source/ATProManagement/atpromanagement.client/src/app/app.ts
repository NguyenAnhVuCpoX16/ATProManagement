import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrls: ['./app.css'],
  standalone: true
})
export class App implements OnInit {

  forecasts: WeatherForecast[] = [];

  constructor(
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.getForecasts();
  }

  getForecasts(): void {

    this.http
      .get<WeatherForecast[]>('/weatherforecast')
      .subscribe({
        next: (result) => {

          console.log(result);

          this.forecasts = result;

        },
        error: (err) => {
          console.error(err);
        }
      });
  }
}
