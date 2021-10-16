import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'watchlog-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  constructor(private http: HttpClient) {}

  visible = false;

  ngOnInit(): void {
    setTimeout(() => (this.visible = true), 6000);
    this.http
      .get('https://pokeapi.co/api/v2/pokemon/ditto?test=1')
      .subscribe((res) => console.log(res));
  }
}
