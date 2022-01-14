import { Component } from '@angular/core';
import { GreetingService } from '@api';
import { map } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  readonly vm$ = this._greetingService
  .get("Quinn")
  .pipe(
    map(greeting => ({ greeting }))
  );
  
  constructor(
    private readonly _greetingService: GreetingService
  ) {}
}
