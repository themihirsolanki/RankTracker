import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { ApiService } from '../../services/api.service';

@Injectable({
    providedIn: 'root',
})
export class ApiGuard implements CanActivate {
    constructor(private apiService: ApiService, private router: Router) {}

    canActivate(): Observable<boolean> {
        return this.apiService.getWebsite().pipe(
            map((response) => {
                return true;
            }),
            catchError((e) => {
                if(e.status == 404) {
                    this.router.navigate(['/setup']);
                    return [false];
                }
                
                console.log("Connection error, redirecting to connection error page");
                this.router.navigate(['/connection-error']);
                return [false];
            })
        );
    }
}