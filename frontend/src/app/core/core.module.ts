import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { ApiCallService } from "./services/api-call.service";

@NgModule({
  declarations: [],
  imports: [HttpClientModule],
  providers: [ApiCallService],
  exports: []
})
export class CoreModule {}
