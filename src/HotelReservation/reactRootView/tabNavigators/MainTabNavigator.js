import * as React from "react";
import { Text, View, Image } from "react-native";
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import { ProfileStack } from "../stackNavigators/ProfileStack";
import { BookingTabNavigator } from "../tabNavigators/BookingTabNavigator";
import { HotelTabNavigator } from "../tabNavigators/HotelTabNavigator";
import colors from "../config/colors";

function HomeScreen() {
    return (
        <View
            style={{ flex: 1, justifyContent: "center", alignItems: "center" }}
        >
            <Text>Home!</Text>
        </View>
    );
}

function SettingsScreen() {
    return (
        <View
            style={{ flex: 1, justifyContent: "center", alignItems: "center" }}
        >
            <Text>Settings!</Text>
        </View>
    );
}

function SettingsScreen2() {
    return (
        <View
            style={{ flex: 1, justifyContent: "center", alignItems: "center" }}
        >
            <Text>Settings!</Text>
        </View>
    );
}

const Tab = createBottomTabNavigator();

export const MainTabNavigator = () => (
   
    <Tab.Navigator 
        initialRouteName="Profile"   
        activeColor={colors.brown}
        barStyle={{ backgroundColor: colors.primary }}
        screenOptions={ () => ({                
            tabBarHideOnKeyboard: true,     
            activeBackgroundColors: colors.brown,
            tabBarIndicatorStyle: { 
                width: 50, 
                height: 50, 
                backgroundColor: colors.brown, 
                borderRadius: 25,
                opacity: 0.6
            },
            tabBarShowLabel: false,
            headerShown: false,
            tabBarStyle: { 
                height: 70,
                backgroundColor: colors.third,
                showLabel: false,
                borderBottomLeftRadius: 20,
                borderBottomRightRadius: 20,
            }   
        })}                         
    >
        <Tab.Screen 
            name="ProfileStack"  
            component={ProfileStack}
            screenOptions={{ headerShown: false }}
            options={{
                headerShown: false,
                tabBarIcon: ({ color, size }) => (
                    <Image source={require("../../assets/mainTabIcons/ProfileIcon.png")} style={{ width: 40, height: 40 }} />
                )}
            }
        />
        <Tab.Screen 
            name="Booking" 
            options={{
                tabBarIcon: ({ color, size }) => (
                    <Image source={require("../../assets/mainTabIcons/BookingIcon.png")} style={{ width: 40, height: 40 }} />
                )}
            }
            component={BookingTabNavigator}
        />
        <Tab.Screen 
            name="Hotel" 
            options={{
                tabBarIcon: ({ color, size }) => (
                    <Image source={require("../../assets/mainTabIcons/HotelIcon.png")} style={{ width: 40, height: 40 }} />
                )}
            }
            component={HotelTabNavigator}
        />            
    </Tab.Navigator>
);
