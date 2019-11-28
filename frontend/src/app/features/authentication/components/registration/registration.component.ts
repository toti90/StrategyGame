import { Component, OnInit } from "@angular/core";
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators
} from "@angular/forms";
import { Router } from "@angular/router";
import { AuthenticationService } from "../../services/authentication.service";
import { LocalDbService } from "src/app/core/services/local-db.service";
import { IUserRequestRegistration, IUserResponseDTO } from "../../models/user";

@Component({
  selector: "app-registration",
  templateUrl: "./registration.component.html",
  styleUrls: ["./registration.component.scss"]
})
export class RegistrationComponent implements OnInit {
  private registrationForm: FormGroup;
  private alert = " ";

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authenticationService: AuthenticationService,
    private localDbService: LocalDbService
  ) {}

  ngOnInit() {
    this.registrationForm = this.formBuilder.group({
      userName: new FormControl("", Validators.required),
      password: new FormControl("", Validators.required),
      confirmPassword: new FormControl("", Validators.required),
      countryName: new FormControl("", Validators.required)
    });
  }

  registerUser(userRequest: IUserRequestRegistration): void {
    this.authenticationService.registerUser(userRequest).subscribe(
      (userToken: IUserResponseDTO) => {
        if (userToken.token != null) {
          this.localDbService.storeToken(userToken.token);
          this.router.navigate(["/battle"]);
        }
      },
      err => (this.alert = err.error.errors.message)
    );
  }
}
