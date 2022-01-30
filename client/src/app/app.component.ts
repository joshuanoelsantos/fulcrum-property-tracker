import { Component } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'property-tracker';

  constructor(private route: ActivatedRoute) {}

  ngOnInit() : void {
    
    this.route.params.forEach((params: Params) => {
      console.log('params'); // Your params called every change
      console.log(params); // Your params called every change
  });
  }
}
