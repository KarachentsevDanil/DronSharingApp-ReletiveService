<template>
    <div>
          <div class="panel panel-body login-form">
            
            <div class="form-group has-feedback has-feedback-left">
                <input type="text" class="form-control" :placeholder="labels.properties.emailLable"
                                          v-model="user.email"
                                          :error-messages="emailErrors"
                                          @input="$v.user.email.$touch()"
                                          @blur="$v.user.email.$touch()"
                                          required>

                <div class="form-control-feedback">
                    <i class="icon-user text-muted"></i>
                </div>
            </div>

            <div class="form-group has-feedback has-feedback-left">
                <input type="text" class="form-control" :placeholder="labels.properties.fullNameLabel"
                                          v-model="user.fullName"
                                          :error-messages="fullNameErrors"
                                          @input="$v.user.fullName.$touch()"
                                          @blur="$v.user.fullName.$touch()"
                                          required>

                <div class="form-control-feedback">
                     <i class="icon-user text-muted"></i>
                </div>
            </div>

            <div class="form-group has-feedback has-feedback-left">
                <input type="password" class="form-control" v-model="user.password"
                                          :error-messages="passwordErrors"
                                          :placeholder="labels.properties.passwordLabel"
                                          @input="$v.user.password.$touch()"
                                          @blur="$v.user.password.$touch()"
                                          required>
                <div class="form-control-feedback">
                    <i class="icon-user-lock text-muted"></i>
                </div>
            </div>
             <div class="form-group">
                <button type="submit" :disabled="isInvaild" @click="submit" class="btn bg-teal btn-block btn-lg">Register</button>
             </div>
            <router-link to="/login" class="btn btn-default btn-block content-group">Login</router-link>
        </div>
    </div>
</template>

<script>
    import * as authenticationService from "../api/authentication-service";
    import * as authTextResources from "../resources/resources";
    import * as mainStoreActions from "../../../store/types/action-types";

    import { mapGetters } from "vuex";
    import { validationMixin } from "vuelidate";
    import { required, minLength, email } from "vuelidate/lib/validators";

    export default {
        mixins: [validationMixin],

        validations: {
            user: {
                email: { required, email },
                password: { required, minLength: minLength(6) },
                fullName: { required }
            }
        },
        data: () => ({
            user: {
                email: "",
                password: "",
                fullName: "",
                birthday: null
            },
            labels: {
                ...authTextResources.lables
            },
            menu: false
        }),
        methods: {
            async submit() {
                let fullName = this.user.fullName.split(" ");

                let data = {
                    Email: this.user.email,
                    Password: this.user.password,
                    FirstName: fullName[0],
                    LastName: fullName[1],
                    DateOfBirthsday: this.user.birthday
                };

                this.$store.dispatch(mainStoreActions.START_LOADING_ACTION, "Account is creating ...");

                let response = await authenticationService.registr(data);

                if (response.data.IsSuccess) {
                    this.$noty.success(authTextResources.popupMessages.accountCreatedMessage);
                    this.$router.push("/login");
                } else {
                    this.$noty.error(authTextResources.popupMessages.accountCreationFailedMessage);
                }

                this.$store.dispatch(mainStoreActions.STOP_LOADING_ACTION);
            }
        },
        computed: {
            isInvaild() {
                return this.$v.$invalid;
            },
            passwordErrors() {
                const errors = [];
                if (!this.$v.user.password.$dirty) return errors;
                !this.$v.user.password.minLength &&
                    errors.push(authTextResources.lables.validationMessages.passwordLengthMessage);
                !this.$v.user.password.required && errors.push(authTextResources.lables.validationMessages.passwordRequiredMessage);
                return errors;
            },
            emailErrors() {
                const errors = [];
                if (!this.$v.user.email.$dirty) return errors;
                !this.$v.user.email.email && errors.push(authTextResources.lables.validationMessages.emailMessage);
                !this.$v.user.email.required && errors.push(authTextResources.lables.validationMessages.emailRequiredMessage);
                return errors;
            },
            fullNameErrors() {
                const errors = [];
                if (!this.$v.user.fullName.$dirty) return errors;
                !this.$v.user.fullName.required && errors.push(authTextResources.lables.validationMessages.fullNameRequiredMessage);
                return errors;
            }
        }
    };
</script>
