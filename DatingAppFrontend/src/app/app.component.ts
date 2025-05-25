import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  http = inject(HttpClient);
  title = 'DatingAppFrontend';
  users: any;
  ngOnInit(): void {
    this.http.get('https://localhost:5128/api/users').subscribe({
      next: (res) => (this.users = res),
      error: (error) => console.log(error),
      complete: () => console.log('completed'),
    });
  }
}
