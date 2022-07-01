import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ServicesService } from '../services/services.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
users:any;
  constructor(private s:ServicesService) { }
registermode=false;
  ngOnInit(): void {
   this.GetUsers();
  }
registertoggle(){
  this.registermode=!this.registermode;
}
GetUsers(){
  this.s.GetUser().subscribe(reponce=>{
    this.users=reponce
  }
  )
}
 
cancleregister(event:boolean){
  this.registermode=event;
}

}
