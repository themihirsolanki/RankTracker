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
        return this.apiService.fetchConfiguration().pipe(
            map((response) => {
                if(response.domain === undefined || response.domain === null) {
                    console.log("Service is down, domain is undefined or null");
                    this.router.navigate(['/setup']);
                }

                console.log("Service is up and running", response);
                return true;
            }),
            catchError((e) => {
                console.log("Error: Service is down" + JSON.stringify(e));
                this.router.navigate(['/connection-error']);
                return [false];
            })
        );
    }
}