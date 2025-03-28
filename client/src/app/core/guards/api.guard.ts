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
        return this.apiService.checkHealth().pipe(
            map((response) => {
                return true;
            }),
            catchError(() => {
                this.router.navigate(['/connection-error']);
                return [false];
            })
        );
    }
}