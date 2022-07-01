import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Toast, ToastrService } from 'ngx-toastr';
import { ServicesService } from '../services/services.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private http:ServicesService,private r:Router ,private t:ToastrService) { }
  model:any={};
  logIn:boolean=false;
  ngOnInit(): void {
  }
  login(){
    this.http.logIn(this.model).subscribe(responce=>{
      this.logIn=true;
      this.r.navigateByUrl("/Home");
      console.log(responce);
    },error=>{
      this.logIn=false;
this.t.error(error.error)
      console.log(error);
    });
    
   
  }
  logout(){
    this.logIn=false;
    this.r.navigateByUrl("/Home");

  }
}
