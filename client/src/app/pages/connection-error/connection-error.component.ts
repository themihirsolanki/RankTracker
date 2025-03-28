import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-connection-error',
  imports: [],
  templateUrl: './connection-error.component.html',
  styleUrl: './connection-error.component.css'
})
export class ConnectionErrorComponent {

  constructor(private router: Router) {}

  retry() {
    this.router.navigate(['/']);
  }
}
