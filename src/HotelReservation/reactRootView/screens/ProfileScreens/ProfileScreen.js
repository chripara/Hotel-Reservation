import React from "react";
import { EllipseButtonPrimary } from "../../components/EllipseButtonPrimary";
import { Card } from "../../components/Card";
import { View, StyleSheet, Text } from "react-native";
import { MainScreen } from "../MainScreen";
import colors from "../../config/colors";
import defaultStyles from "../../config/defaultStyles";


const content = [
    {
        title: "FirstName:",
        text: "Luitgard",            
    },
    {
        title: "LastName:",
        text: "Abdullah",   
    },
    {
        title: "Location:",
        text: "9935 Briarwood DriveLakeville, MN 55044",   
    },
    {
        title: "Email:",
        text: "LuitgardAbdullah@gmail.com",   
    },
    {
        title: "Phone Number:",
        text: "941-812-2553",   
    }
]

export const ProfileScreen = ({ navigation }) => (    
    <MainScreen backgroundColor={colors.secondary}>
        <View style={styles.container}>
            <View style={styles.viewText}>
                <Text style={defaultStyles.text36White}>Profile</Text>                
            </View>
            <Card contentPair={content} numberOfPairs={5}/>           
            <EllipseButtonPrimary
                marginTop={"8%"}
                name={"Logout"}
                onClick={() => navigation.navigate("Logout")}
            />
            <EllipseButtonPrimary
                marginTop={"5%"}
                name={"Edit Profile"}
                onClick={() => navigation.navigate("EditProfile")}
            />
            <EllipseButtonPrimary
                marginTop={"5%"}
                name={"Manage Account"}
                onClick={() => navigation.navigate("ManageAccount")}
            />
        </View>
    </MainScreen>
);

const styles = StyleSheet.create({
    container: {
        flex: 1,
        padding: "3%",
    },
    viewText: {
        position: "relative",
        marginVertical: "5%",
        paddingHorizontal: "5%",
    },
});