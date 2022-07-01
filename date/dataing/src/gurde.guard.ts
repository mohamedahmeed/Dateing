import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { map, Observable } from 'rxjs';
import { ServicesService } from './app/services/services.service';

@Injectable({
  providedIn: 'root'
})
 
export class GurdeGuard implements CanActivate {
  constructor(private s:ServicesService,private t:ToastrService,private r:Router){}
  canActivate():any{
    return this.s.currentuser.pipe(map(u=>{
      if(u) return true
      else{
        return  this.t.error("you shall not pass");
      }
    })
    )
  }
     
    
  
  
}
