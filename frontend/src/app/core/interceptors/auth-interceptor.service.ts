import { Injectable } from "@angular/core";
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse,
  HttpSentEvent
} from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError, filter, take, switchMap } from "rxjs/operators";
import { LocalDbService } from "../services/local-db.service";

@Injectable({
  providedIn: "root"
})
export class AuthInterceptorService implements HttpInterceptor {
  constructor(private localDbService: LocalDbService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<HttpSentEvent>> {
    if (this.localDbService.getAccessToken()) {
      request = this.addToken(request, this.localDbService.getAccessToken());
    }

    return next.handle(request).pipe(
      catchError(error => {
        if (error instanceof HttpErrorResponse && error.status === 401) {
          this.handle401Error();
        } else {
          return throwError(error);
        }
      })
    );
  }

  private addToken(request: HttpRequest<any>, token: string) {
    return request.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
  }

  private handle401Error() {
    console.log("need to logout");
    //TODO: logoutUSer
  }
}
