import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  styles: [`
      :host ::ng-deep button {
          margin-right: .5em;
      }
  `]
})
export class AppComponent {
  title = 'angular-client';
}
