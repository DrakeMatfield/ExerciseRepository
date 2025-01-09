<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0"   xmlns:ext="urn:my-extension"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt">
  <xsl:output method="text" />

  <msxsl:script language="C#" implements-prefix="ext">
    <![CDATA[
    public string FormatDate(string date)
    {
      DateTime dt = DateTime.Parse(date);
      return dt.ToString("dddd, MMM dd, yyyy");
    }
  ]]>
  </msxsl:script>

  <xsl:template match="bio">
    <xsl:text>Bio - </xsl:text>
    <xsl:value-of select="@name" />
    <xsl:text>: </xsl:text>
    <xsl:text>&#10;</xsl:text>
    <!-- Newline -->
    <!--  <xsl:value-of select="profile" />-->
    <xsl:apply-templates select="profile"  />
    <xsl:text>&#10;</xsl:text>
    <!-- Newline -->
    <xsl:apply-templates select="workout_sessions"  />
  </xsl:template>


  <xsl:template match="profile">
    <xsl:text>Profile - </xsl:text>
    <xsl:value-of select="entity/name" />
    <xsl:text>: </xsl:text>
    <xsl:value-of select="entity/description" />
    <xsl:text>&#10;</xsl:text>
    <!-- Newline -->
    <xsl:apply-templates select="plans"  />
  </xsl:template>

  <xsl:template match="plans">
    <xsl:for-each select="plan">
      <xsl:apply-templates select="."  />
    </xsl:for-each>
  </xsl:template>

  <xsl:template match="plan">
    <xsl:text>Plan - </xsl:text>
    <xsl:value-of select="entity/name" />
    <xsl:text>: </xsl:text>
    <xsl:value-of select="entity/description" />
    <xsl:text>&#10;</xsl:text>
    <!-- Newline -->
    <xsl:apply-templates select="routines"  />
  </xsl:template>

  <xsl:template match="routines">
    <xsl:for-each select="routine">
      <xsl:apply-templates select="."  />
      <xsl:text>&#10;</xsl:text>
      <!-- Newline -->
    </xsl:for-each>
  </xsl:template>

  <xsl:template match="routine">
    <xsl:text>Routine - </xsl:text>
    <xsl:value-of select="entity/name" />
    <xsl:text>: </xsl:text>
    <xsl:value-of select="entity/description" />
    <xsl:text>&#10;</xsl:text>
    <!-- Newline -->
    <xsl:apply-templates select="exercise_days"  />
  </xsl:template>

  <xsl:template match="exercise_days">
    <xsl:for-each select="exercise_day">
      <xsl:apply-templates select="."  />
      <xsl:text>&#10;</xsl:text>
      <!-- Newline -->
    </xsl:for-each>
  </xsl:template>

  <xsl:template match="exercise_day">
    <!-- Print the exercise day date using the extension function -->
    <xsl:text>&#9;&#9;&#9;&#9;&#9;&#9;&#9;Created on: </xsl:text>
    <!-- Tab -->
    <xsl:value-of select="ext:FormatDate(date)" />
    <xsl:text>&#10;</xsl:text>
    <!-- Newline -->
    <xsl:value-of select="entity/name" />
    <xsl:text>: </xsl:text>
    <xsl:value-of select="entity/description" />
    <xsl:text>&#10;</xsl:text>
    <!-- Newline -->
    <!-- Iterate over each exercise -->
    <xsl:for-each select="exercises/exercise">

      <!-- Print exercise name -->
      <xsl:value-of select="entity/name" />
      <xsl:text>&#10;</xsl:text>
      <!-- Newline -->
      <xsl:text>-------------></xsl:text>
      <!--  -->
      <xsl:text>&#9;&#9;</xsl:text>
      <!-- Tab -->
      <!--<xsl:text>:&#10;</xsl:text> -->
      <!-- Newline -->

      <!-- Iterate over each set -->
      <xsl:for-each select="sets/set">
        <!-- Print set number, reps, and weight -->
        <xsl:text>set </xsl:text>
        <xsl:value-of select="number" />
        <xsl:text>: [</xsl:text>
        <xsl:value-of select="reps" />
        <xsl:text> x </xsl:text>
        <xsl:value-of select="weight" />
        <xsl:text>]&#9;</xsl:text>
        <!-- Tab -->
      </xsl:for-each>
      <xsl:text>&#10;</xsl:text>
      <!-- Newline -->
    </xsl:for-each>
  </xsl:template>

  <xsl:template match="workout_sessions">
    <xsl:for-each select="workout_session">
      <xsl:apply-templates select="."  />
      <xsl:text>&#10;</xsl:text>
      <!-- Newline -->
    </xsl:for-each>
  </xsl:template>


  <xsl:template match="workout_session">
    <xsl:text>Workout Session: </xsl:text>
    <xsl:value-of select="entity/name" />
    <xsl:text> - </xsl:text>
    <xsl:value-of select="entity/description" />
    <xsl:text>&#10;</xsl:text>
    <!-- Newline -->
    <xsl:apply-templates select="EDay/exercise_day"  />
    <xsl:text>&#10;</xsl:text>
    <!-- Newline -->
  </xsl:template>

  <xsl:template match="EDay/exercise_day">
    <!-- Print the exercise day date using the extension function -->
    <xsl:text>&#9;&#9;&#9;&#9;&#9;&#9;&#9;&#9;&#9;</xsl:text>
    <!-- Tab -->
    <xsl:value-of select="ext:FormatDate(date)" />
    <xsl:text>&#10;</xsl:text>
    <!-- Newline -->
    <xsl:value-of select="entity/name" />
    <xsl:text>: </xsl:text>
    <xsl:value-of select="entity/description" />
    <xsl:text>&#10;</xsl:text>
    <!-- Newline -->
    <!-- Iterate over each exercise -->
    <xsl:for-each select="exercises/exercise">

      <!-- Print exercise name -->
      <xsl:value-of select="entity/name" />
      <xsl:text>&#10;</xsl:text>
      <!-- Newline -->
      <xsl:text>-------------></xsl:text>
      <!--  -->
      <xsl:text>&#9;&#9;</xsl:text>
      <!-- Tab -->
      <!--<xsl:text>:&#10;</xsl:text> -->
      <!-- Newline -->

      <!-- Iterate over each set -->
      <xsl:for-each select="sets/set">
        <!-- Print set number, reps, and weight -->
        <xsl:text>set </xsl:text>
        <xsl:value-of select="number" />
        <xsl:text>: [</xsl:text>
        <xsl:value-of select="reps" />
        <xsl:text> x </xsl:text>
        <xsl:value-of select="weight" />
        <xsl:text>]&#9;</xsl:text>
        <!-- Tab -->
      </xsl:for-each>
      <xsl:text>&#10;</xsl:text>
      <!-- Newline -->
    </xsl:for-each>
  </xsl:template>

</xsl:stylesheet>
