import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-header-info',
  templateUrl: './header-info.component.html',
  styleUrls: ['./header-info.component.scss']
})
export class HeaderInfoComponent implements OnInit {

  @Input() topInfo: string;
  @Input() highlightInfo: string | null;
  @Input() bottomInfo: string | null;
  @Input() showHomeIcon: boolean = false;


  constructor() {
    this.topInfo = ""
    this.highlightInfo = ""
    this.bottomInfo = ""
    this.showHomeIcon=false
  }

  

  ngOnInit(): void {
  }

}
