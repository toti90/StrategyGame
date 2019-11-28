export interface IUserRequest {
  userName: string;
  password: string;
}

export interface IUserRequestRegistration extends IUserRequest {
  confirmPassword: string;
  countryName: string;
}

export interface IUserResponseDTO {
  token: string;
}
