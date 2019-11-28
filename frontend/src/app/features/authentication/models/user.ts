export interface UserRequest {
  userName: string;
  password: string;
}

export interface UserRequestRegistration extends UserRequest {
  confirmPassword: string;
  countryName: string;
}

export interface UserResponseDTO {
  token: string;
}
