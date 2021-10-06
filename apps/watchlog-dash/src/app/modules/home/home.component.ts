import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'watchlog-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  constructor() {}

  visible = false;

  ngOnInit(): void {
    setTimeout(() => (this.visible = true), 6000);
  }
}
