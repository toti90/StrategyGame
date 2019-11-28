import { NgModule } from "@angular/core";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { ApiCallService } from "./services/api-call.service";
import { AuthInterceptorService } from "./interceptors/auth-interceptor.service";

@NgModule({
  declarations: [],
  imports: [HttpClientModule],
  providers: [
    ApiCallService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true
    }
  ],
  exports: []
})
export class CoreModule {}
