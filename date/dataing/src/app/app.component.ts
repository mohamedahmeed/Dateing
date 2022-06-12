import { Component, OnInit } from '@angular/core';

import { User } from './Models/user';
import { ServicesService } from './services/services.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private serve:ServicesService){}
  user:any;
  
  ngOnInit(): void {
    this.serve.GetUser().subscribe({
      next:next=> this.user=next ,
      error:error=> console.log(error)
    })
  }
}
