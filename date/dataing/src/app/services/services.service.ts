import { Injectable, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import {  Users } from '../Models/user';
import { map, ReplaySubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServicesService  {
private CurrentUsersource= new ReplaySubject<Users>(1);
currentuser=this.CurrentUsersource.asObservable();

  constructor(private http: HttpClient) { }
    GetUser(){
  return this.http.get("http://localhost:60022/api/Users");
    }
    logIn(model:any){
      return this.http.post("http://localhost:60022/api/Account/Login",model)
      .pipe(map((responce: any)=>{
        const user=responce;
        if(user){
          localStorage.setItem('user',JSON.stringify(user));
          this.CurrentUsersource.next(user);
        }
      }))
    
    }
    register(model:any){
      return this.http.post("http://localhost:60022/api/Account/Register",model).pipe(
        map((user:any)=>{
          if(user){
            localStorage.setItem('user',JSON.stringify(user));
            this.CurrentUsersource.next(user);
          }
          return user;
        })
      )

    }
    setcurrentUser(user:Users){
      this.CurrentUsersource.next(user);
    }
  logout(){
    localStorage.removeItem('user');
   // this.CurrentUsersource.next(null);

  }
}
