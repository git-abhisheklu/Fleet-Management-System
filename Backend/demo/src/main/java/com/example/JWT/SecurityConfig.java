package com.example.JWT;



import java.util.Collections;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.config.Customizer;
import org.springframework.security.config.annotation.authentication.configuration.AuthenticationConfiguration;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.http.SessionCreationPolicy;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.web.SecurityFilterChain;
import org.springframework.security.web.authentication.www.BasicAuthenticationFilter;
import org.springframework.web.cors.CorsConfiguration;
import org.springframework.web.cors.CorsConfigurationSource;
import com.example.JWT.*;


import jakarta.servlet.http.HttpServletRequest;

@Configuration
public class SecurityConfig {

        @Bean
        SecurityFilterChain securityFilterChain(HttpSecurity security) throws Exception {
            security.csrf(crf->crf.disable());
            security.sessionManagement(session->session.sessionCreationPolicy(SessionCreationPolicy.NEVER));
            
            security.addFilterAfter(new JWTTokenGenerationFilter(), BasicAuthenticationFilter.class);
            security.addFilterBefore(new JWTTokenValidatorFilter(), BasicAuthenticationFilter.class);
            security.authorizeHttpRequests(Auth -> Auth
            	    .requestMatchers("/auth/register", "/auth/signIn").permitAll() // Allow unauthenticated access
         	    .requestMatchers("/**").permitAll());  // Require authentication for other routes

            security.httpBasic(Customizer.withDefaults());

            security.cors(csr->csr.configurationSource(new CorsConfigurationSource() {
                @Override
                public CorsConfiguration getCorsConfiguration(HttpServletRequest request) {
                     CorsConfiguration cfg = new CorsConfiguration();
                     cfg.setAllowedOrigins(Collections.singletonList("http://localhost:3000"));
                     cfg.setAllowedMethods(Collections.singletonList("*"));
                     cfg.setAllowedHeaders(Collections.singletonList("*"));
                     cfg.setAllowCredentials(true);
                     cfg.setExposedHeaders(Collections.singletonList("Authorization"));
                     cfg.setMaxAge(3600L);
                     return cfg;
                }
            }));
            return security.build();
    }

        @Bean
        public AuthenticationManager authenticationManager(AuthenticationConfiguration authenticationConfiguration) throws Exception {
            return authenticationConfiguration.getAuthenticationManager();
        }
    @Bean
    PasswordEncoder encoder(){
        return new BCryptPasswordEncoder();
    }
}