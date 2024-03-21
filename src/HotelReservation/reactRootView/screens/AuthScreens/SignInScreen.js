import React from "react";
import { View, StyleSheet, Text, TextInput } from "react-native";
import { MainScreen } from "../MainScreen";
import colors from "../../config/colors";
import { EllipseButtonSecondary } from "../../components/EllipseButtonSecondary";
import fontStyles from "../../config/StyleSheets/fontStyles";

export const SignInScreen = ({ navigation }) => (
    <MainScreen backgroundColor={colors.primary}>
        <View style={styles.container}>
            <View style={styles.viewText}>
                <Text style={fontStyles.text48White}>Sign In</Text>
            </View>
            <View style={styles.viewText}>
                <Text style={fontStyles.text24White}>Username:</Text>
                <TextInput style={fontStyles.textInput} />
                <Text style={fontStyles.text24White}>Password:</Text>
                <TextInput style={fontStyles.textInput} />
                <Text
                    style={fontStyles.text18White}
                    onPress={() => navigation.navigate("Auth")}
                >
                    Forgot Password?
                </Text>
            </View>
            <EllipseButtonSecondary
                name={"Sign In"}
                onClick={() => navigation.navigate("Welcome")}
                marginTop={"50%"}
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
        marginVertical: "10%",
        paddingHorizontal: "5%",
    }
});
