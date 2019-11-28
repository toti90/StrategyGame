import { Component, OnInit } from "@angular/core";
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators
} from "@angular/forms";
import { AuthenticationService } from "../../services/authentication.service";
import { Router } from "@angular/router";
import { UserRequest, UserResponseDTO } from "../../models/user";
import { LocalDbService } from "src/app/core/services/local-db.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"]
})
export class LoginComponent implements OnInit {
  private loginForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authenticationService: AuthenticationService,
    private localDbService: LocalDbService
  ) {}

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      userName: new FormControl("toti", Validators.required),
      password: new FormControl("Pa$$w0rd", Validators.required)
    });
  }

  loginUser(userRequest: UserRequest): void {
    this.authenticationService.loginUser(userRequest).subscribe(
      (userToken: UserResponseDTO) => {
        if (userToken.token != null) {
          this.localDbService.storeToken(userToken.token);
          this.router.navigate(["/battle"]);
        }
      },
      err => alert(err.error.errors.message)
    );
  }
}
