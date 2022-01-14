import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable()
export class HeadersInterceptor implements HttpInterceptor {

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    const cultureCode = "en-US";

    return next.handle(request.clone({
      headers: request.headers
      .set('Accept-Language', `${cultureCode}`)
    }));
  }
}
